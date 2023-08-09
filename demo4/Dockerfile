FROM jeffrygonzalez/dev-container-for-c:alpine3.18.3 as builder
WORKDIR /app
COPY ./src/ .

RUN gcc -o hello -static hello.c

FROM scratch
WORKDIR /app/
COPY --from=builder ./app/hello ./
ENTRYPOINT [ "/app/hello" ]