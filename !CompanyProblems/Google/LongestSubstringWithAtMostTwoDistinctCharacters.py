
class Solution(object):
    def lengthOfLongestSubstringTwoDistinct(self, s):
        """
        :type s: str
        :rtype: int
        """
        maxSubstringLength=0
        i=0
        j=0
        characters={}
        l=len(s)
        while j<l:
            if s[j] not in characters:
                while len(characters)==2:
                    characters[s[i]]-=1
                    if characters[s[i]]==0:
                        characters.pop(s[i])
                    i+=1
                characters[s[j]]=0
            characters[s[j]]+=1
            maxSubstringLength=max(maxSubstringLength,j-i+1)
            j+=1
        return maxSubstringLength

s=Solution()
print("%s"%(s.lengthOfLongestSubstringTwoDistinct("ccaabbb")==5))
print("%s"%(s.lengthOfLongestSubstringTwoDistinct("eceba")==3))
