[![Main](https://github.com/jaddek/proxymock/actions/workflows/main.yaml/badge.svg?branch=main)](https://github.com/jaddek/proxymock/actions/workflows/main.yaml)
[![SonarCloud](https://github.com/jaddek/proxymock/actions/workflows/sonarcube.yaml/badge.svg)](https://github.com/jaddek/proxymock/actions/workflows/sonarcube.yaml)
## Project idea:

General mock service,
which we can generate via api according to the required structure correct mock objects.

## Reasons

Developers are faced with generating proxy servers or mock servers to implement specific integrations in various environments.

This project involves creating a solution that covers these needs.

## Mission

- generation of mock service for API
- generation of random data according to schemes
- ability to emulate the behavior of services awaiting integration
- proxy to final service

## Request:
generate 10 objects according to the next structure


```json
{
 "id": "uuidV7", 
 "title": "Random title", 
 "description": "random description", 
 "createdAt": "2012-01-02 12:12:12" 
}
```