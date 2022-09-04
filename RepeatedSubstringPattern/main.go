package main

import "fmt"

func main() {
	fmt.Println(repeatedSubstringPattern("bab") == false)
	fmt.Println(repeatedSubstringPattern("aa") == true)
	fmt.Println(repeatedSubstringPattern("ab") == false)
	fmt.Println(repeatedSubstringPattern("a") == false)
	fmt.Println(repeatedSubstringPattern("abab") == true)
	fmt.Println(repeatedSubstringPattern("aba") == false)
	fmt.Println(repeatedSubstringPattern("abcabcabcabc") == true)
}

func repeatedSubstringPattern(s string) bool {
	currentPrefix := ""
	for _, c := range s {
		currentPrefix = currentPrefix + string(c)
		if len(currentPrefix) > len(s)/2 {
			break
		}
		suffix := s[len(s)-len(currentPrefix):]
		if currentPrefix == suffix {
			timesToRepeat := len(s) / len(currentPrefix)
			str := ""
			for i := 0; i < timesToRepeat; i++ {
				str = str + currentPrefix
			}
			if str == s {
				return true
			}
		}
	}

	return false
}
