# Build stage
FROM node:alpine as node

WORKDIR /src
COPY . .

#RUN npm install && npm run build -- local, this works fine, refer here https://github.com/npm/npm/issues/16866
RUN rm -f package-lock.json && npm install

# Run Stage
FROM nginx:alpine
#COPY nginx.conf /etc/nginx/nginx.conf -- local, this works fine
COPY ./nginx.conf /etc/nginx/nginx.conf
COPY --from=node /src/dist /usr/share/nginx/html/movies
