package main

import (
	"fmt"
	"os"
	"strings"
)

func main() {

	args := os.Args[1:]
	input := strings.Join(args, " ")

	fmt.Println(input)
}

func GetOffset(code rune) (int, error) {
	switch {
	case code >= 'A' && code <= 'Z':
		return int(code - 'A'), nil

	case code >= 'a' && code <= 'z':
		return int(code - 'a'), nil

	default:
		return 0, fmt.Errorf("code must be between 'A' and 'Z' or 'a' and 'z'")
	}
}

func EncodeChar(input rune, code rune) (rune, error) {
	offset, err := GetOffset(code)
	if err != nil {
		return 0, err
	}
	switch {
	case input >= 'A' && input <= 'Z':
		return 'A' + ((input - 'A' + rune(offset)) % 26), nil
	case input >= 'a' && input <= 'z':
		return 'a' + ((input - 'a' + rune(offset)) % 26), nil
	default:
		return input, nil
	}
}

func Encode(input string, code rune) (string, error) {
	_, err := GetOffset(code)
	if err != nil {
		return "", err
	}

	encoded := make([]rune, len(input))
	for idx, itm := range input {
		encoded[idx], _ = EncodeChar(itm, code)
	}

	return string(encoded), nil
}
