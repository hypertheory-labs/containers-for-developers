FROM alpine:3.18.3 as builder
WORKDIR /app
RUN apk add build-base
COPY ./src/ .

RUN gcc -o hello -static hello.c

FROM scratch
WORKDIR /app/
COPY --from=builder ./app/hello ./
ENTRYPOINT [ "/app/hello" ]