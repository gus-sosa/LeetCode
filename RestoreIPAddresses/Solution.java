package RestoreIPAddresses;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

class Solution {
    public List<String> restoreIpAddresses(String s) {
        if (s == null || s.length() < 4 || s.length() > 12) {
            return Arrays.asList();
        }

        var retVal = new ArrayList<String>();
        for (int i = 0; i < s.length(); i++) {
            String segment1 = s.substring(0, i);
            if (!areValidSegments(segment1)) {
                continue;
            }
            for (int j = i + 1; j < s.length(); j++) {
                String segment2 = s.substring(i, j);
                if (!areValidSegments(segment2)) {
                    continue;
                }
                for (int k = j + 1; k < s.length(); k++) {
                    String segment3 = s.substring(j, k);
                    String segment4 = s.substring(k);

                    if (areValidSegments(segment3, segment4)) {
                        String ip = String.format(
                                "%s.%s.%s.%s",
                                segment1,
                                segment2,
                                segment3,
                                segment4);
                        retVal.add(ip);
                    }
                }
            }
        }

        return retVal;
    }

    private Boolean areValidSegments(String... segments) {
        return List.of(segments).stream()
                .allMatch(i -> i != null && !i.isEmpty() && Long.parseLong(i) < 2147483648l && Integer.parseInt(i) < 256
                        && !hasLeadingZeros(i));
    }

    private Boolean hasLeadingZeros(String segment) {
        if (segment.length() < 2) {
            return false;
        }
        return segment.charAt(0) == '0';
    }
}