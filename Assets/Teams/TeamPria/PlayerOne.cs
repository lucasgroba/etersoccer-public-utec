using Core.Games;
using Core.Player;
using Core.Utils;
using UnityEngine;
using UnityEditor;

namespace Teams.TeamPria
{
    public class PlayerOne : TeamPlayer
    {
        public override void OnUpdate()
        {
            var ballPosition = GetBallPosition();
            if (Vector3.Distance(ballPosition, GetPosition()) < 4 && Vector3.Distance(GetPosition(),GetMyGoalPosition()) < 4 ){
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
            if(Vector3.Distance(GetPosition(),GetTeamMatesInformation()[0].Position) >= Vector3.Distance(GetPosition(),GetTeamMatesInformation()[1].Position )){
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