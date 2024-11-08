# Stage 1: Build the Angular application
FROM node:18 as build

# Set working directory
WORKDIR /app

# Copy package.json and package-lock.json for dependency installation
COPY package*.json ./

# Install dependencies
RUN npm install --legacy-peer-deps

# Copy the Angular application code
COPY . .

# Build the Angular app

RUN npm run build --prod

# Stage 2: Serve the app with Nginx
FROM nginx:alpine

# Copy the built Angular app from the previous stage
COPY --from=build /app/dist/fishing-booker /usr/share/nginx/html

# Copy the default Nginx configuration file
COPY nginx.conf /etc/nginx/conf.d/default.conf

COPY entrypoint.sh /entrypoint.sh

# Make entrypoint script executable
RUN chmod +x /entrypoint.sh

# Expose port 80
EXPOSE 80

# Start Nginx
ENTRYPOINT ["/entrypoint.sh"]
