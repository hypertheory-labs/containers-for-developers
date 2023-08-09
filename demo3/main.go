package main

import (
	"fmt"
	"log"
	"net/http"
)

func home(w http.ResponseWriter, r *http.Request) {
	fmt.Fprintf(w, "Welcome to Company.Com")
}

func startTheServer() {
	http.HandleFunc("/", home)
	log.Fatal(http.ListenAndServe(":80", nil))
}
func main() {
	fmt.Println("Starting your Web Server")
	startTheServer()
}
