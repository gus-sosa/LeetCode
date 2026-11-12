package FindTheScoreDifferenceInAGame;

public class FindTheScoreDifferenceInAGame {
    public static void main(String[] args) {
        var s = new Solution();
        System.out.println(s.scoreDifference(new int[] { 1, 2, 3 }));
    }

    static class Solution {
        public int scoreDifference(int[] nums) {
            int[] playerStatus = new int[] { 1, 0 };
            int[] playerPoints = new int[] { 0, 0 };
            for (int i = 0; i < nums.length; i++) {
                if (nums[i] % 2 == 1) {
                    swapRoles(playerStatus);
                }
                if ((i + 1) % 6 == 0) {
                    swapRoles(playerStatus);
                }
                assignPoints(playerPoints, playerStatus, nums[i]);
            }
            return playerPoints[0] - playerPoints[1];
        }

        public static void swapRoles(int[] roles) {
            int t = roles[0];
            roles[0] = roles[1];
            roles[1] = t;
        }

        public static void assignPoints(int[] sumPoints, int[] roles, int points) {
            sumPoints[0] += roles[0] * points;
            sumPoints[1] += roles[1] * points;
        }
    }
}
