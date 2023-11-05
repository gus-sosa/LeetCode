package InterleavingString;

public class InterleavingString {
    public static void main(String[] args) {
        Solution s = new Solution();
        System.out.println(s.isInterleave("", "", "") == true);
        System.out.println(s.isInterleave("aabcc", "dbbca", "aadbbcbcac") == true);
        System.out.println(s.isInterleave("aabcc", "dbbca", "aadbbbaccc") == false);
    }
}
