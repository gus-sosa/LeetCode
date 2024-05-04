package StringWithoutAAAOrBBB;

class Solution {
    public String strWithout3a3b(int a, int b) {
        StringBuilder retVal = new StringBuilder();
        for (; a > 0 && b > 0; a--, b--) {
            retVal.append("ab");
        }

        for (int i = 0; a > 1; a--) {
            retVal.insert(i, 'a');
            i += 3;
        }
        if (a == 1) {
            retVal.append('a');
        }

        for (int i = 1; b > 2; b--) {
            retVal.insert(i, 'b');
            i += 3;
        }
        for (; b > 0; b--) {
            retVal.insert(0, 'b');
        }

        return retVal.toString();
    }
}