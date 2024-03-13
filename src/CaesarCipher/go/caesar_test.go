package main

import (
	"fmt"
	"testing"
)

func TestGetOffset(t *testing.T) {
	tests := []struct {
		name   string
		code   rune
		offset int
	}{
		{"test M", 'M', 12},
		{"test Z", 'Z', 25},
		{"test A", 'A', 0},
		{"test m", 'm', 12},
		{"test z", 'z', 25},
		{"test a", 'a', 0},
	}

	for _, tc := range tests {
		t.Run(tc.name, func(t *testing.T) {
			offset, err := GetOffset(tc.code)
			if err != nil {
				t.Errorf("GetOffset() error = %v", err)
				return
			}
			if offset != tc.offset {
				t.Errorf("GetOffset() = %v, expected %v", offset, tc.offset)
			}
		})
	}
}

func TestEncode(t *testing.T) {
	tests := []struct {
		input    string
		code     rune
		expected string
	}{
		{"Hello World", 'H', "Olssv Dvysk"},
		{"Hello, World", 'H', "Olssv, Dvysk"},
		{"hello, world", 'h', "olssv, dvysk"},
		{"hello world", 'C', "jgnnq yqtnf"},
	}

	for _, tc := range tests {
		name := fmt.Sprintf("Test %s by %s -> %s", tc.input, string(tc.code), tc.expected)
		t.Run(name, func(t *testing.T) {
			result, err := Encode(tc.input, tc.code)
			if err != nil {
				t.Errorf("GetOffset() error = %v", err)
				return
			}
			if result != tc.expected {
				t.Errorf("Encode() = %v, expected %v", result, tc.expected)
			}
		})
	}
}
