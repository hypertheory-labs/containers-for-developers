FROM golang:alpine3.18 AS builder
EXPOSE 80

WORKDIR $GOPATH/src/demo3/server/
COPY . . 
RUN go build -o /go/bin/server

FROM scratch
COPY --from=builder /go/bin/server /go/bin/server
ENTRYPOINT ["/go/bin/server"]