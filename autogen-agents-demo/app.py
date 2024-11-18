import os
import autogen
from autogen import AssistantAgent, UserProxyAgent

#startmessage = '''
#       use the following weather service api https://open-meteo.com/en/docs to get the next four days weather reports for atlanta and put the max and min temperature values into a file temperatures.txt each line should follow the format [day] - [maxtemp] : [mintemp]
#    '''

startmessage= 'write numbers 1 to a 100 to a file named numbers.txt'

config_list = [{
        "model": "codellama-70b-python-hf",
        "api_type": "open_ai",
        "api_base": "http://localhost:1234/v1/",
        "api_key": "NULL"
    }
]


#print(os.environ["OPENAI_API_KEY"])
#llm_config ={"model": "gpt-4", "api_key": os.environ["OPENAI_API_KEY"]}
llm_config = {
    "config_list": config_list
}

logging_session_id = autogen.runtime_logging.start(logger_type="file", config={"filename": "runtime.log"})
print("Logging session ID: " + str(logging_session_id))

assistant = AssistantAgent("assistant", llm_config=llm_config)

user_proxy = UserProxyAgent(
    "userproxy",
    human_input_mode="NEVER",
    llm_config=False,
    code_execution_config={
        "executor": autogen.coding.LocalCommandLineCodeExecutor(work_dir="coding", timeout=280)  
    }
)


user_proxy.initiate_chat(
    assistant,
    message=startmessage
)

autogen.runtime_logging.stop()