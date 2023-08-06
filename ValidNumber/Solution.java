package ValidNumber;

import java.util.regex.Pattern;

public class Solution {
    private Pattern integerPattern = Pattern.compile("[+-]?\\d+");
    private Pattern decimalPattern = Pattern.compile("[+-]?(\\d+\\.\\d+|\\d+\\.|\\.\\d+)");

    public boolean isNumber(String s) {
        int[] tailResult = validNumberTail(s);
        if (tailResult[0] == 0) {
            return false;
        }
        int tailIndex = tailResult[1];
        String ss = String.copyValueOf(s.toCharArray());
        if (tailIndex > 0) {
            ss = s.substring(0, tailIndex - 1);
        }

        return isValidInteger(ss) || isValidDecimal(ss);
    }

    private int[] validNumberTail(String s) {
        int indexE = s.indexOf('e');
        String suffix = null;
        boolean valid = true;
        if (indexE != -1) {
            indexE++;
            suffix = s.substring(indexE);
            valid = !containsE(suffix);
        }
        if (suffix == null) {
            indexE = s.indexOf('E');
            if (indexE != -1) {
                indexE++;
                suffix = s.substring(indexE);
                valid = !containsE(suffix);
            }
        }
        if (suffix != null) {
            valid = valid && isValidInteger(suffix);
        }
        return valid ? new int[] { 1, indexE } : new int[] { 0, -1 };
    }

    private boolean isValidInteger(String s) {
        return s != null && integerPattern.matcher(s).matches();
    }

    private boolean isValidDecimal(String s) {
        return s != null && decimalPattern.matcher(s).matches();
    }

    private boolean containsE(String s) {
        return s != null && (s.contains("E") || s.contains("e"));
    }
}