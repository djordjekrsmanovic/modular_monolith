#!/bin/sh

# Replace $BACKEND_URL in Nginx configuration files
if [ -n "$BACKEND_URL" ]; then
  find /usr/share/nginx/html -type f -exec sed -i "s~\\\$BACKEND_URL~$BACKEND_URL~g" {} \;
fi

# Start Nginx
nginx -g 'daemon off;'
