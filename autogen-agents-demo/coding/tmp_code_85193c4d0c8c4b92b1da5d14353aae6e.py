import requests
import json
from datetime import datetime, timedelta

# Construct the URL for the API request
base_url = "https://api.open-meteo.com/v1/forecast"
latitude = 33.7490
longitude = -84.3880
params = {
    "latitude": latitude,
    "longitude": longitude,
    "daily_temperature": "morning,day,evening",
    "date_to": (datetime.now() - timedelta(days=1)).strftime("%Y-%m-%d"),
    "date_from": (datetime.now() - timedelta(days=4)).strftime("%Y-%m-%d"),
}

# Make the request to the Open-Meteo API
response = requests.get(base_url, params=params)
response.raise_for_status()

# Parse the JSON response
weather_data = response.json()

# Write the weather data to a file
with open("temperatures.txt", "w") as outfile:
    json.dump(weather_data, outfile, indent=4)