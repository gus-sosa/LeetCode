class Solution(object):
    def findBuildings(self, heights):
        maxHeight = -1
        retVal = []
        index = len(heights)-1
        for i in heights[::-1]:
            if i > maxHeight:
                retVal.append(index)
            maxHeight = max(maxHeight, i)
            index -= 1
        list.sort(retVal)
        return retVal


s = Solution()
print(s.findBuildings([4, 2, 3, 1]))
print(s.findBuildings([4, 3, 2, 1]))
print(s.findBuildings([1, 3, 2, 4]))
