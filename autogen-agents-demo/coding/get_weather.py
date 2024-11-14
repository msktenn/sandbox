# filename: get_weather.py

import requests

# base API endpoint
base_url = "https://api.open-meteo.com/v1/forecast"
# parameters for the GET request
parameters = {
    "latitude": 33.7490,
    "longitude": -84.3880,
    "daily": ("temperature_2m_min,temperature_2m_max")
}
# Send GET request to the Open-Meteo API
response = requests.get(base_url, params=parameters)
# Extract JSON data from the response
data = response.json()
# Make sure the request was successful
assert response.status_code == 200, f"Request failed with status {response.status_code}"

# Get the temperature and date information
dates = data['daily']['time'][0:4]
min_temps = data['daily']['temperature_2m_min'][0:4]
max_temps = data['daily']['temperature_2m_max'][0:4]

# Open the file to write the temperatures
with open('temperatures.txt', 'w') as file:
    for i in range(4):
        # Write the day and temperatures to the file
        line = f"{dates[i]} - {max_temps[i]} : {min_temps[i]}\n"
        file.write(line)

print("Temperatures for the next four days have been successfully written to 'temperatures.txt'")