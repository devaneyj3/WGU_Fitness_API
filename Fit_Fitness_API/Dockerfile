# Use an official Node.js runtime as the base image
FROM node:16.16

# Set the working directory in the Docker container
WORKDIR /usr/src/app

# Copy package.json and package-lock.json into the root directory of the app
COPY package*.json ./

# Install the app dependencß
RUN npm install

# Bundle the app source inside the Docker image
COPY . .

# Expose port 3000 for the app to be accessible
EXPOSE 3000


# Start the app using nodemon
CMD [ "npx", "nodemon", "app.js" ]
