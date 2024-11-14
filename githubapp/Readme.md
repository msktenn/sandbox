
https://docs.github.com/en/developers/apps


Creating App
https://docs.github.com/en/developers/apps/creating-a-github-app

Developer Settings
    Github App
        App Name - (Unique first come first serve)
        Description - MD Text
        Homepage URL : App website
        IDENTIFY and Authorize Users
            Callback URL : Url to redirect to for additional setup
            Expire user authorization tokens (Default ON)
            Request user authorization (OAuth) during installation (Default Off)
        Post Installation
            Setup URL
            redirect on update
        Webhook
            Active
            Webhook URL
            Webhook Secret (optional)
            Register for pipelines 
                Link Repository
            Event Subscriptions

        Permissions
        
        App Installation
            Private
            Public


    OAuth App
        Application Name
        Homepage URL
        Application Description
        Authorization callback URL

    Auth Tokens


cat configuregithub |grep --color=never -e request -e response | cut -d"[" -f3 | cut -d"]" -f1 | grep -v "<" | base64 -d

lt --port 8000