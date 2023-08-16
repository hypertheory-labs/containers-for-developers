FROM node:18.17.0-alpine as build
WORKDIR /app
RUN npm i -g npm@9.7.2

COPY package*.json .
RUN npm ci

COPY . .

RUN npm run build

FROM nginx:1.25.2-alpine
COPY --from=build /app/dist/app /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
