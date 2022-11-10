using Core.Games;
using Core.Player;
using Core.Utils;
using UnityEngine;

namespace Teams.TeamPria
{
    public class PlayerThree : TeamPlayer
    {

        private float DistanceToGoal = 10;
        private float DistanceToBall = 4;
        private float MinDistanceToRivals = 5;
        private float DistanceToPlayer = 10;
        public override void OnUpdate()
        {
            
            var ballPosition = GetBallPosition();
            if (Vector3.Distance(GetPosition(),ballPosition ) < DistanceToBall){
                MoveBy(GetDirectionTo(ballPosition));
            }
            else{
                //var playerOnePosition = GetTeamMatesInformation()[0].Position;
                var playerTwoPosition = GetTeamMatesInformation()[1].Position;
                if(Vector3.Distance(GetPosition(),playerTwoPosition) > DistanceToPlayer){
                    MoveBy(GetDirectionTo(ballPosition));
                }else{
                    GoTo(FieldPosition.B3);
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
                    var playerTwoPosition = GetTeamMatesInformation()[1].Position;
                    if(Vector3.Distance(GetTeamMatesInformation()[0].Position, GetRivalGoalPosition() ) >= Vector3.Distance(GetTeamMatesInformation()[1].Position,GetRivalGoalPosition())){
                        var directionToPlayerTwo = GetDirectionTo(playerTwoPosition);
	                    ShootBall(directionToPlayerTwo, ShootForce.Medium);
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
                DistanceToBall = 4;
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

        public override FieldPosition GetInitialPosition() => FieldPosition.B3;

        public override string GetPlayerDisplayName() => "Martin";
    }
}