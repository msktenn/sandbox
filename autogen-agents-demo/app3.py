import autogen

config_list_mistral={
    "model": "NotRequired",
    'base_url': "http://0.0.0.0:37704",
    'api_key': "NULL",
     "price": [0, 0],
}

config_list_codellama={
    "model": "NotRequired",
    'base_url': "http://0.0.0.0:4000",
    'api_key': "NULL",
     "price": [0, 0],
}


llm_config_mistral={
    "config_list": [config_list_mistral],
    "cache_seed": None,  # Turns off caching, useful for testing different models
}

llm_config_codellama={
    "config_list": [config_list_codellama],
    "cache_seed": None,  # Turns off caching, useful for testing different models
}


assistant = autogen.AssistantAgent(
    name="Assistant",
    llm_config=llm_config_mistral,
)

coder = autogen.AssistantAgent(
    name="Coder",
    llm_config=llm_config_codellama
)

user_proxy = autogen.UserProxyAgent(
    name="user_proxy",
    human_input_mode="NEVER",
    max_consecutive_auto_reply=10,
    is_termination_msg=lambda x: x.get("content", "").rstrip().endswith("TERMINATE"),
    code_execution_config={
        "executor": autogen.coding.LocalCommandLineCodeExecutor(work_dir="coding", timeout=280)  
    },
    llm_config=llm_config_mistral,
    system_message="""Reply TERMINATE if the task has been solved at full satisfaction
    Otherwise, reply CONTINUE, or the reason why the task is not solved yet."""
)

task="""
Tell me a joke
"""

groupchat = autogen.GroupChat(agents=[user_proxy,coder,assistant], messages=[], max_round=12)

manager = autogen.GroupChatManager(groupchat=groupchat, llm_config=llm_config_mistral)
user_proxy.initiate_chat(manager, message=task)