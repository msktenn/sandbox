# filename: fetch_temperatures.py

import requests
import json

# API endpoint
url = "https://api.open-meteo.com/v1/forecast"

# Define parameters
params = {
    "latitude": 33.7490,  # Latitude for Atlanta
    "longitude": -84.3880,  # Longitude for Atlanta
    "daily": "temperature_2m_max,temperature_2m_min",  # Get daily max and min 2m temperatures
}

response = requests.get(url, params=params)

# Parse JSON response
data = response.json()

# Get daily forecasts
forecasts = data.get('daily').get('temperature_2m_max')[:4] + data.get('daily').get('temperature_2m_min')[:4]

# Create and write to file
with open('temperatures.txt', 'w') as f:
    for forecast in forecasts:
        f.write(str(forecast) + '\n')