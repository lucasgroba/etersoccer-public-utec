﻿using Core.Games;
using Core.Player;
using Core.Utils;
using UnityEngine;

namespace Teams.TeamPria
{
    public class PlayerTwo : TeamPlayer
    {
        private  float DistanceToGoal = 10;
        private  float DistanceToBall = 5;
        private  float MinDistanceToRivals = 5;
        private float DistanceToPlayer = 10;
        public override void OnUpdate()
        {
            
            var ballPosition = GetBallPosition();
            if (Vector3.Distance(GetPosition(),ballPosition ) < DistanceToBall){
                MoveBy(GetDirectionTo(ballPosition));
            }
            else{
                //var playerOnePosition = GetTeamMatesInformation()[0].Position;
                var playerThreePosition = GetTeamMatesInformation()[1].Position;
                if(Vector3.Distance(GetPosition(),playerThreePosition) > DistanceToPlayer){
                    MoveBy(GetDirectionTo(ballPosition));
                }else{
                    GoTo(FieldPosition.B1);
                }
            }
        }

        public override void OnReachBall()
        {
            if (Vector3.Distance(GetPosition(), GetRivalGoalPosition() ) > DistanceToGoal ){
                MoveBy(GetDirectionTo(GetRivalGoalPosition()));
                if(Vector3.Distance(GetPosition(),GetRivalsInformation()[0].Position) <= MinDistanceToRivals || 
                Vector3.Distance(GetPosition(),GetRivalsInformation()[1].Position) <= MinDistanceToRivals || 
                Vector3.Distance(GetPosition(),GetRivalsInformation()[2].Position) <= MinDistanceToRivals)
                {
                    var playerOnePosition = GetTeamMatesInformation()[0].Position;
                    var playerThreePosition = GetTeamMatesInformation()[1].Position;
                    if(Vector3.Distance(GetTeamMatesInformation()[0].Position, GetRivalGoalPosition() ) >= Vector3.Distance(GetTeamMatesInformation()[1].Position,GetRivalGoalPosition())){
                        var directionToPlayerThree = GetDirectionTo(playerThreePosition);
	                    ShootBall(directionToPlayerThree, ShootForce.Medium);
                    }
                    else{
                        var directionToPlayerOne = GetDirectionTo(playerOnePosition);
	                    ShootBall(directionToPlayerOne, ShootForce.Medium);
                    }  
                }
            }
            else{
                ShootBall(GetDirectionTo(GetRivalGoalPosition()), ShootForce.High);
            }
            
        }

        public override void OnScoreBoardChanged(ScoreBoard scoreBoard)
        {
            if(GetMyScore() > GetRivalScore() ){
                DistanceToGoal = 10;
                DistanceToBall = 5;
                MinDistanceToRivals = 5;
                DistanceToPlayer = 10;
            }
            else{
                DistanceToGoal = 12;
                DistanceToBall = 6;
                MinDistanceToRivals = 8;
                DistanceToPlayer = 10;
            }
        }

        public override FieldPosition GetInitialPosition() => FieldPosition.C1;

        public override string GetPlayerDisplayName() => "Messi";
    }
}