# BlockSnifferIp

An util for monitor which IPs are scanning / trying to hack our PC


# Targets

- [x] Monitor and record who are doing port scanning

- [ ] Update windows firewall to block their IPs (manually)

- [ ] Automatically update firewall rules by match logic

- [ ] Records to cloud and apply cloud records

- [ ] Thinking...


# Directory Structure

- BlockSnifferIp

A dll to handle all program main logic.


- BlockSnifferIpApp

One single exe to do everyting.


- BlockSnifferIpGui

Looking same as `BlockSnifferIpApp`, working with `BlockSnifferIpService` but nothing for now.


- BlockSnifferIpService

A background service. Nothing for now.


- BlockSnifferIpTest

A command-line mode exe. Usually I would make some test code in it.


- Run

Build target folder.


# Build

It is a Visual Studio project. You can easily build with default settings.


