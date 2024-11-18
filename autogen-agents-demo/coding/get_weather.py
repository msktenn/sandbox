# filename: get_weather.py

import requests

# base API endpoint
base_url = "https://api.open-meteo.com/v1/forecast"
# parameters for the GET request
parameters = {
    "latitude": 33.7490,
    "longitude": -84.3880,
    "daily": "temperature_2m_min,temperature_2m_max"
}

# Send GET request to the Open-Meteo API
response = requests.get(base_url, params=parameters)
# Extract JSON data from the response
data = response.json()

# Extract 'time', 'temperature_2m_min', and 'temperature_2m_max' lists
dates = data['daily']['time']
min_temps = data['daily']['temperature_2m_min']
max_temps = data['daily']['temperature_2m_max']

# Open the file to write the temperatures
with open('temperatures.txt', 'w') as file:
    # Only consider next four days
    for i in range(4):
        # Write the date, max temperature, and min temperature to the file
        file.write(f'{dates[i]} - {max_temps[i]} : {min_temps[i]}\n')