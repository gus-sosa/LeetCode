class Solution(object):
    def accountsMerge(self, accounts):
        """
        :type accounts: List[List[str]]
        :rtype: List[List[str]]
        """
        acctDict = {}
        emailDict = {}
        for a in accounts:
            acct = a[0]
            emails = a[1:]
            for email in emails:
                if email in emailDict:
                    acc = emailDict[email]
                    if acc not in acctDict:
                        acctDict[acc] = {}
                    acctDict[acc][email] = 1
                else:
                    emailDict[email] = acct
                    if acct not in acctDict:
                        acctDict[acct] = {}
                    acctDict[acct][email] = 1

        retVal = []
        for (acct, emails) in acctDict.items():
            retVal.append([acct]+[e for e in emails])
        return retVal

s=Solution()
print(s.accountsMerge([["John","johnsmith@mail.com","john_newyork@mail.com"],["John","johnsmith@mail.com","john00@mail.com"],["Mary","mary@mail.com"],["John","johnnybravo@mail.com"]]))