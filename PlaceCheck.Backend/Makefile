# Wczytywanie zmiennych z .env dla backendu
include .env
export $(shell sed 's/=.*//' .env)

# Repozytorium Docker Hub dla backendu
IMAGE_NAME=$(DOCKER_USERNAME)/$(REPO_NAME)

# Funkcja do podbijania wersji PATCH
increment_patch_version = $(shell echo $(IMAGE_VERSION) | awk -F. -v OFS=. '{sub(/[^0-9.]*$$/, "", $$3); $$3 = $$3 + 1; print $$1"."$$2"."$$3}')

# Budowanie obrazu backendu
.PHONY: docker_backend
docker_backend:
	@echo "Building Docker image $(IMAGE_NAME):$(IMAGE_VERSION)"
	docker build --build-arg IMAGE_VERSION=$(IMAGE_VERSION) --pull -t $(IMAGE_NAME):$(IMAGE_VERSION) -f PlaceCheck.WebApi/Dockerfile .
	@echo "Tagging $(IMAGE_NAME):latest"
	docker tag $(IMAGE_NAME):$(IMAGE_VERSION) $(IMAGE_NAME):latest

# Wypychanie obrazu backendu do Docker Hub z tagiem wersji i latest
.PHONY: push_backend
push_backend: docker_backend
	@echo "Pushing Docker image $(IMAGE_NAME):$(IMAGE_VERSION)"
	docker push $(IMAGE_NAME):$(IMAGE_VERSION)
	@echo "Pushing Docker image $(IMAGE_NAME):latest"
	docker push $(IMAGE_NAME):latest

# Aktualizacja wersji backendu w .env
.PHONY: update_backend_version
update_backend_version:
	@NEW_VERSION=$(call increment_patch_version); \
	echo "Updating .env with IMAGE_VERSION=$$NEW_VERSION"; \
	sed -i "s/^IMAGE_VERSION=$(IMAGE_VERSION)/IMAGE_VERSION=$$NEW_VERSION/" .env
	$(eval IMAGE_VERSION=$(NEW_VERSION))

# Pełne wdrożenie backendu: budowanie, wypychanie i aktualizacja wersji
.PHONY: deploy
deploy: push_backend update_backend_version
	@echo "Deployment of $(IMAGE_NAME):$(IMAGE_VERSION) completed successfully with latest tag!"
