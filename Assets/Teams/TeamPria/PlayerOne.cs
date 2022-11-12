using Core.Games;
using Core.Player;
using Core.Utils;
using UnityEngine;
using UnityEditor;

namespace Teams.Pria2
{
    public class PlayerOne : TeamPlayer
    {
        public override void OnUpdate()
        {
            var ballPosition = GetBallPosition();
            if (Vector3.Distance(ballPosition, GetPosition()) < 5 && Vector3.Distance(GetPosition(),GetMyGoalPosition()) < 4 ){
                MoveBy(GetDirectionTo(ballPosition));
            }
            else {
                GoTo(FieldPosition.A2);
            }
        }

        public override void OnReachBall()
        {
            
            var playerTwoPosition = GetTeamMatesInformation()[0].Position;
            var playerThreePosition = GetTeamMatesInformation()[1].Position;
            float distanceP2 = 0.0f;  
            float distanceP3 = 0.0f;
            for (int i = 0 ; i < 3; i++){
                if(Vector3.Distance(GetTeamMatesInformation()[0].Position, GetRivalsInformation()[i].Position) > distanceP2){
                    distanceP2 = Vector3.Distance(GetTeamMatesInformation()[0].Position, GetRivalsInformation()[i].Position);
                    Debug.Log(distanceP2.ToString());
                }
            }
            for (int i = 0 ; i < 3; i++){
                if(Vector3.Distance(GetTeamMatesInformation()[1].Position, GetRivalsInformation()[i].Position) > distanceP3){
                    distanceP3 = Vector3.Distance(GetTeamMatesInformation()[1].Position, GetRivalsInformation()[i].Position);
                    Debug.Log(distanceP3.ToString());
                }
            }
            if(distanceP3 > distanceP2 ){
                var directionToPlayerThree = GetDirectionTo(playerThreePosition);
	            ShootBall(directionToPlayerThree, ShootForce.Medium);
            }
            else{
                var directionToPlayerTwo = GetDirectionTo(playerTwoPosition);
	            ShootBall(directionToPlayerTwo, ShootForce.Medium);
            }

        }

        public override void OnScoreBoardChanged(ScoreBoard scoreBoard)
        {

        }

        public override FieldPosition GetInitialPosition() => FieldPosition.A2;

        public override string GetPlayerDisplayName() => "Lucas";
    }
}