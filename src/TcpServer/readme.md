# TCP/IP Server

## Summary

TCP/IP is the network protocol underlying all internet communications.  

Many of the protocols running on top of TCP/IP were created using simple text mnemonics.

## Challenge

* Create a TCP/IP socket listener service listing
* This service should respond to input from a user

## Bonus

* Write a chat program where responses are broadcast to others clients connected to the system. 

## Suggestions

* Telnet and Netcat can be used to connect to arbtation TCP/IP ports
  * Telnet in intended to be used as a text terminal and as such may include some extra 
    overhead information so if you use it for testing make sure to handle or ignore that 
    information.

## Common TCP/IP Ports

This is a list of some simple testing protocols and their related port numbers.

| Port | Protocol | Description                                                                             |
| 7    | Echo     | Echo will respond back to the calling client with whatever it receives                  |
| 9    | Discard  | Discard will simple throw away and not response to any client requests                  |
| 13   | Daytime  | This service should return text for the current date/time for any received request      |
| 19   | Chargen  | This service will send characters to a client ignoring any input requests               |
| 23   | Telnet   | This is simple terminal service that relays client requests to a shell process          |
| 37   | Time     | This service should respond with a 32bit number of seconds since JAN 1 1900 00:00AM UTC |
| 194  | IRC      | Internet relay chat, this is a chat protocol defined by RFC 1459                        |
