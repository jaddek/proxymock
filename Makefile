DOCKER_COMPOSE = docker compose

COMPOSE_FILE = docker-compose.yml

DOCKER_COMPOSE_ENV_LOCAL = $(DOCKER_COMPOSE) -f $(COMPOSE_FILE)

run: local-run
build-up: local-build down up
up: local-docker-up
down: local-docker-down
restart: down up
ps: local-docker-ps
logs: local-docker-logs
build: local-build

local-run:
	./mvnw spring-boot:run

local-build:
	./mvnw -Dmaven.test.skip=true package

local-docker-up:
	$(DOCKER_COMPOSE_ENV_LOCAL) up -d --build --force-recreate --remove-orphans

local-docker-down:
	$(DOCKER_COMPOSE_ENV_LOCAL) down --remove-orphans

local-docker-ps:
	$(DOCKER_COMPOSE_ENV_LOCAL) ps --all

local-docker-logs:
	$(DOCKER_COMPOSE_ENV_LOCAL) logs

.PHONY: tests

