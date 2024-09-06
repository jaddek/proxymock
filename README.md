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

Request
```http request
POST {host}\api\mock
```
Body

```json
{
  "result": {
    "type": "object",
    "scheme": {
      "dateTime": {
        "type": "dateTime",
        "format": "y-m-d H:i:s"
      }
    },
    "date": {
      "type": "date",
      "format": "y-m-d"
    },
    "address": {
      "type": "address",
      "nullable": true
    },
    "id": {
      "type": "int",
      "range": {
        "min": 0,
        "max": 255
      },
      "nullable": false
    },
    "name": {
      "type": "string",
      "length": {
        "min": 0,
        "max": 255
      },
      "nullable": false,
      "default": 0
    },
    "uuid": {
      "type": "uuidV4",
      "nullable": true
    },
    "int": {
      "type": "int",
      "unsigned": true,
      "range": {
        "min": 0,
        "max": 255
      },
      "nullable": false,
      "default": 0
    },
    "float": {
      "type": "float",
      "unsigned": true,
      "range": {
        "min": 0,
        "max": 255
      },
      "nullable": false,
      "default": 0
    },
    "decimal": {
      "type": "decimal",
      "unsigned": true,
      "range": {
        "min": 0,
        "max": 255
      },
      "nullable": false,
      "default": 0
    },
    "email": {
      "type": "email",
      "nullable": false
    }
  }
}
```
Response
```json
{
  "result": {
    "dateTime": "1909-01-01 01:01:01",
    "date": "1909-01-01", 
    "address": null,
    "id": 101,
    "name": "hello world",
    "uuid": null,
    "int": 1,
    "float": 1.01,
    "decimal": 1.01010101,
    "email": "some@email.com"
  }
}

```

Request
```http request
POST {host}\api\mock
```
Body

```json
{
  "result": [{
    "dateTime": {
      "format": "y-m-d H:i:s"
    },
    "date": {
      "format": "y-m-d"
    },
    "address": {
      "nullable": true
    },
    "id": {
      "type": "int",
      "range": {
        "min": 0,
        "max": 255
      },
      "nullable": false
    },
    "name": {
      "type": "string",
      "length": {
        "min": 0,
        "max": 255
      },
      "nullable": false,
      "default": 0
    },
    "uuid": {
      "type": "uuidV4",
      "nullable": true
    },
    "int": {
      "type": "int",
      "unsigned": true,
      "range": {
        "min": 0,
        "max": 255
      },
      "nullable": false,
      "default": 0
    },
    "float": {
      "type": "float",
      "unsigned": true,
      "range": {
        "min": 0,
        "max": 255
      },
      "nullable": false,
      "default": 0
    },
    "decimal": {
      "type": "decimal",
      "unsigned": true,
      "range": {
        "min": 0,
        "max": 255
      },
      "nullable": false,
      "default": 0
    },
    "email": {
      "nullable": false
    },
    "person": {
      "type": "object",
      "scheme": {
        "email": {
          "nullable": false
        }
      }
    }
  }]
}
```
Response
```json
{
  "result": [{
    "dateTime": "1909-01-01 01:01:01",
    "date": "1909-01-01", 
    "address": null,
    "id": 101,
    "name": "hello world",
    "uuid": null,
    "int": 1,
    "float": 1.01,
    "decimal": 1.01010101,
    "email": "some@email.com",
    "person": {
      "email": "another@email.com"
    }
  }]
}

```
