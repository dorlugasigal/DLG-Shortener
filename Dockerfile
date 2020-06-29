FROM node:10.13.0-alpine as node
WORKDIR DLG-Shortener/ClientApp
COPY public ./public
COPY src/index.jsx ./src/index.jsx
COPY package*.json ./
RUN npm install --progress=true --loglevel=silent
COPY src ./src
RUN npm run build

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS builder
RUN dotnet restore
RUN dotnet publish -c Release -r linux-musl-x64 -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY --from=builder /app .
COPY --from=node /app/build ./wwwroot


ENTRYPOINT ["./"]