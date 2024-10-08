DOCKER_COMPOSE = docker compose

COMPOSE_FILE = docker-compose.yml

DOCKER_COMPOSE_ENV_LOCAL = $(DOCKER_COMPOSE) -f $(COMPOSE_FILE)

run: local-run
bup: local-build down up
up: local-docker-up
down: local-docker-down
restart: down up
ps: local-docker-ps
logs: local-docker-logs
build: local-build
tr: tests-run

local-run:
	dotnet run

local-build:
	dotnet build
local-docker-up:
	$(DOCKER_COMPOSE_ENV_LOCAL) up -d --build --force-recreate --remove-orphans

local-docker-down:
	$(DOCKER_COMPOSE_ENV_LOCAL) down --remove-orphans

local-docker-ps:
	$(DOCKER_COMPOSE_ENV_LOCAL) ps --all

local-docker-logs:
	$(DOCKER_COMPOSE_ENV_LOCAL) logs

tests-run:
	dotnet test --logger "console;verbosity=detailed;consoleLoggerParameters=PerformanceSummary"

.PHONY: tests

