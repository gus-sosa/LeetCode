class Solution(object):
    def findMissingRanges(self, nums, lower, upper):
        """
        :type nums: List[int]
        :type lower: int
        :type upper: int
        :rtype: List[str]
        """
        if len(nums) == 0:
            return [self.generateRange(lower, upper)]

        retVal = []
        pos = 0
        l = len(nums)-1
        for (pos, value) in enumerate(nums):
            if pos == 0:
                continue
            if value != nums[pos-1]+1:
                a = nums[pos-1]+1
                b = nums[pos]-1
                retVal.append(self.generateRange(a, b))

        if nums[0] != lower:
            retVal.insert(0, self.generateRange(lower, nums[0]-1))

        if nums[len(nums)-1] != upper:
            retVal.append(self.generateRange(nums[len(nums)-1]+1, upper))

        return retVal

    def generateRange(self,a, b):
        if a == b:
            return "%s" % a
        else:
            return "%s->%s" % (a, b)


s = Solution()
s.findMissingRanges([], 1,1)
s.findMissingRanges([0, 1, 3, 50, 75], 0, 99)
