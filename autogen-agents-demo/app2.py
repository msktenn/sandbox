import openai
from autogen import AssistantAgent

try:
    # Configure OpenAI API to use your local LLM server
    openai.api_base = 'http://localhost:1234/v1'
    openai.api_key = ''  # Assuming no API key is required

    # Create the AssistantAgent instance
    assistant = AssistantAgent()

    # Set the model and completion parameters
    assistant.model = 'llama-3.2-3b-instruct'
    assistant.completion_params = {
        'temperature': 0.7,
        'max_tokens': -1,
    }

    # Define the system prompt and user message
    assistant.system_prompt = "Always answer in rhymes. Today is Thursday"
    user_message = "What day is it today?"

    # Get the assistant's response to the user message
    response = assistant.step(user_input=user_message)

    # Print the assistant's response
    print(response)

except Exception as e:
    print(f"An error occurred: {e}")
