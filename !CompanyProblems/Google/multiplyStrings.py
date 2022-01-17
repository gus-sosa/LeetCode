from audioop import reverse


class Solution(object):
    def multiply(self, num1, num2):
        """
        :type num1: str
        :type num2: str
        :rtype: str
        """
        if num1 == "0" or num2 == "0":
            return "0"
        if num1 == "1":
            return num2
        if num2 == "1":
            return num1
        result = ''
        for i in num2:
            mulResult = self.multiplyOneDigit(num1, i)
            result = result+'0'
            result = self.sumNumbers(result, mulResult)
        return result

    def sumNumbers(self, numberOne, numberTwo):
        carry = 0
        result = ''
        currentPos = 1
        while len(numberOne) >= currentPos or len(numberTwo) >= currentPos:
            digitOne = 0
            if len(numberOne) >= currentPos:
                digitOne = int(numberOne[-currentPos])
            digitTwo = 0
            if len(numberTwo) >= currentPos:
                digitTwo = int(numberTwo[-currentPos])
            r = digitOne+digitTwo+carry
            result += "%s" % (r % 10)
            carry = int(r/10)
            currentPos += 1
        if carry > 0:
            result += "%s" % (carry)
        return result[::-1]

    def multiplyOneDigit(self, number, digit):
        result = ''
        carry = 0
        digit = int(digit)
        for i in number[::-1]:
            r = int(i)*digit+carry
            result += "%s" % (r % 10)
            carry = int(r/10)
        if carry > 0:
            result += "%s" % (carry)
        return result[::-1]


s = Solution()
print(s.multiply("2", "3") == "6")
