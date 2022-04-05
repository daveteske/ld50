using Godot;
using ld50game.signals;
using System;
using System.Collections.Generic;

public class CrazyIdea : Node2D
{
    public PackedScene AtomKinScene;

    public RandomNumberGenerator rng = new RandomNumberGenerator();

    public CustomSignals CustomSignals;

    public StaticBody2D CurrentLevel;

    public Timer ParticleSpawnTimer;

    public int ParticalCount = 0;

    public CrazyIdea()
    {

    }

    public override void _Ready()
    {
        rng.Randomize();
        
        CustomSignals = GetNode<CustomSignals>("/root/CustomSignals");
        CustomSignals.Connect(nameof(CustomSignals.SetDangerLevel), this, nameof(OnSetDangerLevel));
        CustomSignals.Connect(nameof(CustomSignals.GameOver), this, nameof(OnGameOver));

        AtomKinScene = (PackedScene)GD.Load("res://scenes/AtomKin.tscn");
        ParticleSpawnTimer = GetNode<Timer>("ParticleSpawnTimer");

    }

    public void OnSetDangerLevel(int level)
    {
        GetNode<AudioStreamPlayer>("DanglerLevelSfx").Play();

    }

    public void OnGameOver()
    {
        ParticleSpawnTimer.Stop();
        GetTree().CallGroup("atoms", nameof(AtomKin.Stop));
        GetNode<AudioStreamPlayer>("GameOverSfx").Play();
        GetNode<Button>("HUD/StartButton").Visible = true;
        GetNode<AudioStreamPlayer>("BackgroundMusic").Stop();
        GetNode<ShieldsV2>("ShieldsV2").IsActive = false;
    }

    public void OnParticleSpawnTimerTimeout()
    {
        ParticalCount++;

        var atom = (AtomKin)AtomKinScene.Instance();
        
        var spawnIndex = (ParticalCount % 4) + 1;
        var spawnNode = GetNode<Position2D>($"Level01/SpawnPoint{spawnIndex}");
        var spawnLoc = spawnNode.GlobalPosition;

        atom.Position = spawnLoc;
        atom.RotationDegrees = rng.RandfRange(0,359);
        //atom.Modulate = new Color(1.5f, 1.5f, 1.5f);
        AddChild(atom);
        GetNode<Label>("HUD/ScoreLabel").Text = ParticalCount.ToString();

    }

    public void OnStartButtonPressed()
    {
        GetNode<Button>("HUD/StartButton").Visible = false;
        StartNewGame();
    }
    public void StartNewGame()
    {
        GameReset();

        ParticleSpawnTimer.Start();
        GetNode<AudioStreamPlayer>("NewGameSfx").Play();
        GetNode<AudioStreamPlayer>("BackgroundMusic").Play();

    }

    public void GameReset()
    {
        // Self
        GetTree().CallGroup("atoms", nameof(AtomKin.Remove));
        ParticalCount = 0;

        // Timer
        ParticleSpawnTimer.WaitTime = 1;
        //DangerZone
        //Level01
        // Shields
        var ShieldsV2Node = GetNode<ShieldsV2>("ShieldsV2");
        ShieldsV2Node.IsActive = true;
        ShieldsV2Node.ResetShields();

        // Hud
        
        // Audio
        GetNode<AudioStreamPlayer>("BackgroundMusic").VolumeDb = GD.Linear2Db(.05f);

    }

}
