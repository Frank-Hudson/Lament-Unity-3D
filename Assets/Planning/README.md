# Specific, Detailed Plans

## Data

### Key

- `components`: A module with data and functionality which you can attach to a Game Object (in Unity), or Entity (in general ECS systems)
- `scripts`: Custom Components (from Unity)

```yaml
scene1:
    name: House
    objects:
        - name: player
          scripts:
              - name: Character
                fields:
                    asset: Data/Entities/PLAYER.character.json (1)
              - name: PlayerMove
              - name: PlayerJump
              - name: EntityData
          components:
              BoxCollider:
              RigidBody:  
          children:
              - name: sprite
                components:
                    - SpriteRenderer:
                          sprite: Textures/player.png
        - name: dialogue
          scripts:
              - 
        - name: hud
          scripts:
              - 
        - name: bed
          scripts:
              - name: BillboardSprite

scene2:
    name: Road 1
    objects:
        - player
        - hud
        - dialogue
        - name: 
```

``(1) Currently, all `*.character.json` files are in place as `*.npc.json` instead``
