package InterleavingString;

class Solution {
    private int[][][][] map;
    private String s1;
    private String s2;
    private String s3;

    public boolean isInterleave(String s1, String s2, String s3) {
        map = new int[s1.length() + 2][s2.length() + 2][s3.length() + 2][2];
        this.s1 = s1;
        this.s2 = s2;
        this.s3 = s3;
        return isInterleaveRecur(0, 0, 0, 0) || isInterleaveRecur(0, 0, 0, 1);
    }

    private Boolean isInterleaveRecur(int posS1, int posS2, int posS3, int isS1Turn) {
        if (map[posS1][posS2][posS3][isS1Turn] == 1
                || (posS1 == s1.length() && posS2 == s2.length() && posS3 == s3.length())) {
            map[posS1][posS2][posS3][isS1Turn] = 1;
            return true;
        }
        if (map[posS1][posS2][posS3][isS1Turn] == 2) {
            return false;
        }
        if ((isS1Turn == 0 && posS1 == s1.length()) || (isS1Turn == 1 && posS2 == s2.length())
                || posS3 == s3.length()) {
            map[posS1][posS2][posS3][isS1Turn] = 2;
            return false;
        }

        boolean flag = false;
        if (isS1Turn == 0) {
            if (s1.charAt(posS1) == s3.charAt(posS3)
                    && (isInterleaveRecur(posS1 + 1, posS2, posS3 + 1, isS1Turn)
                            || isInterleaveRecur(posS1 + 1, posS2, posS3 + 1, (isS1Turn + 1) % 2))) {
                flag = true;
            }
        } else {
            if (s2.charAt(posS2) == s3.charAt(posS3)
                    && (isInterleaveRecur(posS1, posS2 + 1, posS3 + 1, isS1Turn)
                            || isInterleaveRecur(posS1, posS2 + 1, posS3 + 1, (isS1Turn + 1) % 2))) {
                flag = true;
            }
        }

        map[posS1][posS2][posS3][isS1Turn] = flag ? 1 : 2;
        return flag;
    }
}