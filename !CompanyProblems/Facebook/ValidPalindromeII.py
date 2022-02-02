class Solution(object):
    def validPalindrome(self, s):
        def recur(start, end, diffs):
            if start >= end:
                return True
            if diffs > 1:
                return False
            if s[start] == s[end]:
                return recur(start+1, end-1, diffs)
            diffs += 1
            if s[start+1] == s[end] and s[start] == s[end-1]:
                return recur(start+1, end, diffs) or recur(start, end-1, diffs)
            if s[start+1] == s[end]:
                return recur(start+1, end, diffs)
            if s[start] == s[end-1]:
                return recur(start, end-1, diffs)
            diffs += 1
            return recur(start, end, diffs)
        return recur(0, len(s)-1, 0)


s = Solution()
print("%s" % (s.validPalindrome(
    "aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga")))
print("%s" % (s.validPalindrome("abba")))
print("%s" % (s.validPalindrome("ab")))
print("%s" % (s.validPalindrome("a")))
print("%s" % (s.validPalindrome("aba")))
print("%s" % (s.validPalindrome("abca")))
print("%s" % (s.validPalindrome("abc")))
