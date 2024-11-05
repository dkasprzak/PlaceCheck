# Wczytywanie zmiennych z .env
include .env
export $(shell sed 's/=.*//' .env)

# Automatyczne podbijanie wersji PATCH
.PHONY: increment_patch
increment_patch:
	@echo "Current version: $(IMAGE_TAG)"
	@NEW_VERSION=$$(echo $(IMAGE_TAG) | awk -F. -v OFS=. '{sub(/[^0-9.]*$$/, "", $$3); $$3 = $$3 + 1; print $$1"."$$2"."$$3}'); \
	echo "New version: $$NEW_VERSION"; \
	if [ -f .env ]; then \
		sed -i "s/^IMAGE_TAG=$(IMAGE_TAG)/IMAGE_TAG=$$NEW_VERSION/" .env; \
	fi

# Pełna nazwa obrazu
IMAGE_NAME=$(DOCKER_USERNAME)/$(REPO_NAME):$(IMAGE_TAG)

# Budowanie obrazu
.PHONY: docker
docker: increment_patch
	@echo "Building Docker image $(IMAGE_NAME)"
	docker build --build-arg IMAGE_VERSION=$(IMAGE_TAG) --pull -t $(IMAGE_NAME) -f PlaceCheck.WebApi/Dockerfile .

# Wypychanie obrazu do Docker Hub
.PHONY: push
push: docker
	@echo "Pushing Docker image to Docker Hub: $(IMAGE_NAME)"
	docker push $(IMAGE_NAME)

# Pełne wdrożenie: budowanie i wypychanie
.PHONY: deploy
deploy: push
	@echo "Deployment of $(IMAGE_NAME) completed successfully!"
