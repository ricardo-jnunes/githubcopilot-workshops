# Function that convert Celsius to Fahrenheit
def celsius_to_fahrenheit(celsius):
    """
    Convert temperature from Celsius to Fahrenheit.
    Formula: (celsius * 9/5) + 32
    Parameters:
    celsius (float): Temperature in Celsius.
    
    Returns:
    float: Temperature in Fahrenheit.
    """
    fahrenheit = (celsius * 9/5) + 32
    return fahrenheit

## Generating Sample Data 
# Create a list of 5 users with id, name, email
users = [
    {"id": 1, "name": "Alice", "email": "alice@example.com"},
    {"id": 2, "name": "Bob", "email": "bob@example.com"},
    {"id": 3, "name": "Charlie", "email": "charlie@example.com"},
    {"id": 4, "name": "David", "email": "david@example.com"},
    {"id": 5, "name": "Eve", "email": "eve@example.com"}
]