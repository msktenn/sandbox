# If you come from bash you might have to change your $PATH.
# export PATH=$HOME/bin:/usr/local/bin:$PATH

# Path to your oh-my-zsh installation.
export ZSH="/Users/dad/.oh-my-zsh"

# Set name of the theme to load --- if set to "random", it will
# load a random theme each time oh-my-zsh is loaded, in which case,
# to know which specific one was loaded, run: echo $RANDOM_THEME
# See https://github.com/robbyrussell/oh-my-zsh/wiki/Themes
ZSH_THEME="robbyrussell"

# Set list of themes to pick from when loading at random
# Setting this variable when ZSH_THEME=random will cause zsh to load
# a theme from this variable instead of looking in ~/.oh-my-zsh/themes/
# If set to an empty array, this variable will have no effect.
# ZSH_THEME_RANDOM_CANDIDATES=( "robbyrussell" "agnoster" )

# Uncomment the following line to use case-sensitive completion.
# CASE_SENSITIVE="true"

# Uncomment the following line to use hyphen-insensitive completion.
# Case-sensitive completion must be off. _ and - will be interchangeable.
# HYPHEN_INSENSITIVE="true"

# Uncomment the following line to disable bi-weekly auto-update checks.
# DISABLE_AUTO_UPDATE="true"

# Uncomment the following line to automatically update without prompting.
# DISABLE_UPDATE_PROMPT="true"

# Uncomment the following line to change how often to auto-update (in days).
# export UPDATE_ZSH_DAYS=13

# Uncomment the following line if pasting URLs and other text is messed up.
# DISABLE_MAGIC_FUNCTIONS=true

# Uncomment the following line to disable colors in ls.
# DISABLE_LS_COLORS="true"

# Uncomment the following line to disable auto-setting terminal title.
# DISABLE_AUTO_TITLE="true"

# Uncomment the following line to enable command auto-correction.
# ENABLE_CORRECTION="true"

# Uncomment the following line to display red dots whilst waiting for completion.
# COMPLETION_WAITING_DOTS="true"

# Uncomment the following line if you want to disable marking untracked files
# under VCS as dirty. This makes repository status check for large repositories
# much, much faster.
# DISABLE_UNTRACKED_FILES_DIRTY="true"

# Uncomment the following line if you want to change the command execution time
# stamp shown in the history command output.
# You can set one of the optional three formats:
# "mm/dd/yyyy"|"dd.mm.yyyy"|"yyyy-mm-dd"
# or set a custom format using the strftime function format specifications,
# see 'man strftime' for details.
# HIST_STAMPS="mm/dd/yyyy"

# Would you like to use another custom folder than $ZSH/custom?
# ZSH_CUSTOM=/path/to/new-custom-folder

# Which plugins would you like to load?
# Standard plugins can be found in ~/.oh-my-zsh/plugins/*
# Custom plugins may be added to ~/.oh-my-zsh/custom/plugins/
# Example format: plugins=(rails git textmate ruby lighthouse)
# Add wisely, as too many plugins slow down shell startup.
plugins=(git)

source $ZSH/oh-my-zsh.sh

# User configuration

# export MANPATH="/usr/local/man:$MANPATH"

# You may need to manually set your language environment
# export LANG=en_US.UTF-8

# Preferred editor for local and remote sessions
# if [[ -n $SSH_CONNECTION ]]; then
#   export EDITOR='vim'
# else
#   export EDITOR='mvim'
# fi

# Compilation flags
# export ARCHFLAGS="-arch x86_64"

# Set personal aliases, overriding those provided by oh-my-zsh libs,
# plugins, and themes. Aliases can be placed here, though oh-my-zsh
# users are encouraged to define aliases within the ZSH_CUSTOM folder.
# For a full list of active aliases, run `alias`.
#
# Example aliases
# alias zshconfig="mate ~/.zshrc"
# alias ohmyzsh="mate ~/.oh-my-zsh"



export PATH="$PATH:/usr/local/git/bin:/sw/bin/:/usr/local/:/usr/local/sbin:/usr/local/mysql/bin"
export PATH="$PATH:/Users/wofsure/Applications/TFSE"
export PATH="$PATH:/Applications/Visual Studio Code.app/Contents/Resources/app/bin"
export PATH="$PATH:/usr/local/opt/liquibase/bin"
export PATH="/usr/local/opt/openjdk/bin:$PATH"
export PATH="$PATH:/opt/flutter/bin"

export CPPFLAGS="-I/usr/local/opt/openjdk/include"
export BLOCKSIZE=1k
export JAVA_HOME=/usr/local/opt/java
export LIQUIBASE_HOME=/usr/local/opt/liquibase/libexec



alias cp='cp -iv'                           # Preferred 'cp' implementation
alias mv='mv -iv'                           # Preferred 'mv' implementation
alias mkdir='mkdir -pv'                     # Preferred 'mkdir' implementation
alias ls='ls -GFha'                          # Preferred 'ls' implementation
alias ll='ls -FGlAhp'                       # Preferred 'll' implementation
#alias ll='ls -lGaf'g
alias less='less -FSRXc'                    # Preferred 'less' implementation
cd() { builtin cd "$@"; ll; }               # Always list directory contents upon 'cd'
alias cd..='cd ../'                         # Go back 1 directory level (for fast typers)
alias ..='cd ../'                           # Go back 1 directory level
alias ...='cd ../../'                       # Go back 2 directory levels
alias .3='cd ../../../'                     # Go back 3 directory levels
alias .4='cd ../../../../'                  # Go back 4 directory levels
alias .5='cd ../../../../../'               # Go back 5 directory levels
alias .6='cd ../../../../../../'            # Go back 6 directory levels
alias edit='code'                           # edit:         Opens any file in sublime editor
alias f='open -a Finder ./'                 # f:            Opens current directory in MacOS Finder
alias ~="cd ~"                              # ~:            Go Home
alias c='clear'                             # c:            Clear terminal display
alias which='type -all'                     # which:        Find executables
alias path='echo -e ${PATH//:/\\n}'         # path:         Echo all executable Paths
alias show_options='shopt'                  # Show_options: display bash options settings
alias fix_stty='stty sane'                  # fix_stty:     Restore terminal settings when screwed up
alias cic='set completion-ignore-case On'   # cic:          Make tab-completion case-insensitive
mcd () { mkdir -p "$1" && cd "$1"; }        # mcd:          Makes new Dir and jumps inside
trash () { command mv "$@" ~/.Trash ; }     # trash:        Moves a file to the MacOS trash
ql () { qlmanage -p "$*" >& /dev/null; }    # ql:           Opens any file in MacOS Quicklook Preview
alias DT='tee ~/Desktop/terminalOut.txt'    # DT:           Pipe content to file on MacOS Desktop
alias p4merge='/Applications/p4merge.app/Contents/MacOS/p4merge'
alias brewup='brew update; brew upgrade; brew cleanup; brew doctor'
alias 4x='cd ~/code/4x/wms/fourx'
alias setup='cd ~/code/4x/dev-env/setup/mac'
alias 4xdomain='cd ~/Oracle/Middleware/wls12130/user_projects/domains/fourxDomain'
alias dr='docker'
alias pg_start="launchctl load ~/Library/LaunchAgents"
alias pg_stop="launchctl unload ~/Library/LaunchAgents"
hf () { history | grep "$@"; }

#   lr:  Full Recursive Directory Listing
#   ------------------------------------------
alias lr='ls -R | grep ":$" | sed -e '\''s/:$//'\'' -e '\''s/[^-][^\/]*\//--/g'\'' -e '\''s/^/   /'\'' -e '\''s/-/|/'\'' | less'


# Searching
alias qfind="find . -name "                 # qfind:    Quickly search for file
ff () { /usr/bin/find . -name "$@" 2>&1 | grep -v "find:"; }      # ff:       Find file under the current directory
ffs () { /usr/bin/find . -name "$@"'*' 2>&1 | grep -v "find:"; }  # ffs:      Find file whose name starts with a given string
ffe () { /usr/bin/find . -name '*'"$@" 2>&1 | grep -v "find:"; }  # ffe:      Find file whose name ends with a given string
ffc () { /usr/bin/find . -name '*'"$@"'*' 2>&1 | grep -v "find:"; }  # ffe:      Find file whose name ends with a given string

# Searching Docker Volume
dff () {docker run --rm -i -v=$1:/tmp/myvolume busybox find '/tmp/myvolume/' -name "$2" 2>&1 | grep -v "find:"; }  # ffe:      Find file whose name ends with a given string
dffc () {docker run --rm -i -v=$1:/tmp/myvolume busybox find '/tmp/myvolume/' -name '*'"$2"'*' 2>&1 | grep -v "find:"; }  # ffe:      Find file whose name ends with a given string
dll () { docker run --rm -i -v=$1:/tmp/myvolume busybox ls -FlAhp '/tmp/myvolume/'"$2" }
dv () {docker volume $1 $2}

# Command Shell stuff
showa () { /usr/bin/grep --color=always -i -a1 $@ ~/Library/init/bash/aliases.bash | grep -v '^\s*$' | less -FSRXc ; }
#showa () { /usr/bin/grep --color=always -i -a1 $@ ~/.zshrc | grep -v '^\s*$' | less -FSRXc ; }
alias reload='source ~/.zshrc'

#File stuff
zipf () { zip -r "$1".zip "$1" ; }          # zipf:         To create a ZIP archive of a folder
alias numFiles='echo $(ls -1 | wc -l)'      # numFiles:     Count of non-hidden files in current dir
alias make1mb='mkfile 1m ./1MB.dat'         # make1mb:      Creates a file of 1mb size (all zeros)
alias make5mb='mkfile 5m ./5MB.dat'         # make5mb:      Creates a file of 5mb size (all zeros)
alias make10mb='mkfile 10m ./10MB.dat'      # make10mb:     Creates a file of 10mb size (all zeros)
delf () { find . -type f -name "$@" -exec rm '{}' + }   
delfs () { find . -type f -name "$@"'*' -exec rm '{}' + }   
delfe () { find . -type f -name '*'"$@" -exec rm '{}' + }   
delfc () { find . -type f -name '*'"$@"'*' -exec rm '{}' + }   
deld () {rm -r "$@"}

#   ---------------------------
#   5.  PROCESS MANAGEMENT
#   ---------------------------

#   findPid: find out the pid of a specified process
#   -----------------------------------------------------
#       Note that the command name can be specified via a regex
#       E.g. findPid '/d$/' finds pids of all processes with names ending in 'd'
#       Without the 'sudo' it will only find processes of the current user
#   -----------------------------------------------------
findPid () { lsof -t -c "$@" ; }

#   memHogsTop, memHogsPs:  Find memory hogs
#   -----------------------------------------------------
alias memHogsTop='top -l 1 -o rsize | head -20'
alias memHogsPs='ps wwaxm -o pid,stat,vsize,rss,time,command | head -10'

#   cpuHogs:  Find CPU hogs
#   -----------------------------------------------------
alias cpu_hogs='ps wwaxr -o pid,stat,%cpu,time,command | head -10'

#   topForever:  Continual 'top' listing (every 10 seconds)
#   -----------------------------------------------------
alias topForever='top -l 9999999 -s 10 -o cpu'

#   ttop:  Recommended 'top' invocation to minimize resources
#   ------------------------------------------------------------
#       Taken from this macosxhints article
#       http://www.macosxhints.com/article.php?story=20060816123853639
#   ------------------------------------------------------------
alias ttop="top -R -F -s 10 -o rsize"

#   my_ps: List processes owned by my user:
#   ------------------------------------------------------------
my_ps() { ps $@ -u $USER -o pid,%cpu,%mem,start,time,bsdtime,command ; }


#   ---------------------------
#   6.  NETWORKING
#   ---------------------------
alias myip='curl ip.appspot.com'                    # myip:         Public facing IP Address
alias netCons='lsof -i'                             # netCons:      Show all open TCP/IP sockets
alias flushDNS='dscacheutil -flushcache'            # flushDNS:     Flush out the DNS Cache
alias lsock='sudo /usr/sbin/lsof -i -P'             # lsock:        Display open sockets
alias lsockU='sudo /usr/sbin/lsof -nP | grep UDP'   # lsockU:       Display only open UDP sockets
alias lsockT='sudo /usr/sbin/lsof -nP | grep TCP'   # lsockT:       Display only open TCP sockets
alias ipInfo0='ipconfig getpacket en0'              # ipInfo0:      Get info on connections for en0
alias ipInfo1='ipconfig getpacket en1'              # ipInfo1:      Get info on connections for en1
alias openPorts='sudo lsof -i | grep LISTEN'        # openPorts:    All listening connections
alias showBlocked='sudo ipfw list'                  # showBlocked:  All ipfw rules inc/ blocked IPs

#   ii:  display useful host related informaton
#   -------------------------------------------------------------------
ii() {
    echo -e "\nYou are logged on ${RED}$HOST"
    echo -e "\nAdditionnal information:$NC " ; uname -a
    echo -e "\n${RED}Users logged on:$NC " ; w -h
    echo -e "\n${RED}Current date :$NC " ; date
    echo -e "\n${RED}Machine stats :$NC " ; uptime
    echo -e "\n${RED}Current network location :$NC " ; scselect
    echo -e "\n${RED}Public facing IP Address :$NC " ;myip
    #echo -e "\n${RED}DNS Configuration:$NC " ; scutil --dns
    echo
}

#git bash completion
#if [ -f $(brew --prefix)/etc/bash_completion ]; then
#  . $(brew --prefix)/etc/bash_completion
#fi

#   ---------------------------------------
#   7.  SYSTEMS OPERATIONS & INFORMATION
#   ---------------------------------------
alias mountReadWrite='/sbin/mount -uw /'    # mountReadWrite:   For use when booted into single-user

alias duhs='du -hs'    # Size of current folder


#   cleanupDS:  Recursively delete .DS_Store files
#   -------------------------------------------------------------------
alias cleanupDS="find . -type f -name '*.DS_Store' -ls -delete"

#   finderShowHidden:   Show hidden files in Finder
#   finderHideHidden:   Hide hidden files in Finder
#   -------------------------------------------------------------------
alias finderShowHidden='defaults write com.apple.finder ShowAllFiles TRUE'
alias finderHideHidden='defaults write com.apple.finder ShowAllFiles FALSE'

#   cleanupLS:  Clean up LaunchServices to remove duplicates in the "Open With" menu
#   -----------------------------------------------------------------------------------
alias cleanupLS="/System/Library/Frameworks/CoreServices.framework/Frameworks/LaunchServices.framework/Support/lsregister -kill -r -domain local -domain system -domain user && killall Finder"

#    screensaverDesktop: Run a screensaver on the Desktop
#   -----------------------------------------------------------------------------------
alias screensaverDesktop='/System/Library/Frameworks/ScreenSaver.framework/Resources/ScreenSaverEngine.app/Contents/MacOS/ScreenSaverEngine -background'

#   ---------------------------------------
#   8.  WEB DEVELOPMENT
#   ---------------------------------------

alias apacheEdit='sudo edit /etc/httpd/httpd.conf'      # apacheEdit:       Edit httpd.conf
alias apacheRestart='sudo apachectl graceful'           # apacheRestart:    Restart Apache
alias editHosts='sudo edit /etc/hosts'                  # editHosts:        Edit /etc/hosts file
alias herr='tail /var/log/httpd/error_log'              # herr:             Tails HTTP error logs
alias apacheLogs="less +F /var/log/apache2/error_log"   # Apachelogs:   Shows apache error logs
httpHeaders () { /usr/bin/curl -I -L $@ ; }             # httpHeaders:      Grabs headers from web page

#   httpDebug:  Download a web page and show info on what took time
#   -------------------------------------------------------------------
httpDebug () { /usr/bin/curl $@ -o /dev/null -w "dns: %{time_namelookup} connect: %{time_connect} pretransfer: %{time_pretransfer} starttransfer: %{time_starttransfer} total: %{time_total}\n" ; }

#.netenvironment
export ASPNETCORE_ENVIRONMENT="development"

#
# AWS Helpers
#. ~/code/app.restrike.io/src-deploy/.restrike-profile.sh

aliashelp() {
    echo '
    dalias
    mkalias
    kcalias
    galias
    dnalias
    alsalias'
}
#
# DotNet Helpers
dnalias() {
    echo 'alias dn="dotnet"
        alias dnap="dotnet add package"
        alias dnns="dotnet new sln -o"
        alias dnsa="dotnet sln add"
        alias dnncl="dotnet new classlib -o"
        alias dnnxu="dotnet new xunit -o"
        dnaddref(){dotnet add "$1" reference "$2"}
        alias dnab="dotnet build"'
}
alias dn="dotnet"
alias dnap="dotnet add package"
alias dnb="dotnet build"
alias dnns="dotnet new sln -o"
alias dnsa="dotnet sln add"
alias dnncl="dotnet new classlib -o"
alias dnnxu="dotnet new xunit -o"
dnaddref(){dotnet add "$1" reference "$2"}



#
# Docker Helpers
dalias() {
    echo '
    dri docker remove image  
    drc () {docker rm $(docker ps -a | grep "\w*\$1\w*")}
    dstop () {docker stop "\$1"}
    dstart () {docker start "\$1"}
    di () {docker images | grep "\$1"}
    dps () {docker ps | grep "\$1"}
    dpsa () {docker ps -a | grep "\$1"}
    drbash () {sudo docker run -it --entrypoint /bin/bash \$1}
    dcb() {docker-compose -f "\$1" build --progress=plain --no-cache}
    dcu() {docker-compose -f "\$1" up}
    dcd() {docker-compose -f "\$1" down}
    '
}
dri () {docker rmi $(docker images | grep -o "\w*$1\w*")}
drc () {docker rm $(docker ps -a | grep "\w*$1\w*")}
dstop () {docker stop "$1"}
dstart () {docker start "$1"}
di () {docker images | grep "$1"}
dps () {docker ps | grep "$1"}
dpsa () {docker ps -a | grep "$1"}
drbash () {sudo docker run -it --entrypoint /bin/bash $1}
dcb() {docker-compose -f "$1" build --progress=plain --no-cache}
dcu() {docker-compose -f "$1" up}
dcd() {docker-compose -f "$1" down}
#docker-compose -f $imageLocation/$containerprefix-run.yml $addnetworkfile $addfluentdfile -p $envCode up -d
#docker-compose -f $imageLocation/nginxproxy-run.yml -f $imageLocation/nginxproxy-run-$envCode.yml run --rm --entrypoint
#docker-compose -f $imageLocation/$switch-run.yml -f $imageLocation/$switch-run-addnetwork.yml -p $envCode down 


#
# minikube helpers
mkalias(){
    echo '
    alias mk="minikube"
    mks () {minikube start --mount-string="$BLOCKCHAIN_HOME/ethereum/volumes:/data/eth"  --disk-size 50000mb --mount; eval $(minikube docker-env);}
    mkeval() {eval $(minikube docker-env)}
    mkstat () {minikube status}
    mkstp () {minikube stop}
    mkp () {minikube pause}
    mkt () {minikube tunnel}
    '    
}
alias mk='minikube'
mks () {minikube start --mount-string="$BLOCKCHAIN_HOME/ethereum/volumes:/data/eth"  --disk-size 50000mb --mount; eval $(minikube docker-env);}
mkeval() {eval $(minikube docker-env)}
mkstat () {minikube status}
mkstp () {minikube stop}
mkp () {minikube pause}
mkt () {minikube tunnel}

#
# kubernetes helpers helpers
kcalias(){
    echo '
    alias kc="kubectl"
    kcg () {kubectl get $1 $2 $3}
    kcgn () {kubectl get nodes}
    kcgs () {kubectl get services}
    kcgp () {kubectl get pods}
    kcgpv () {kubectl get pv}
    kcgpvc () {kubectl get pvc}
    kcgpw () {kubectl get pods -o wide}
    kcgr () {kubectl get replicaset}
    kcgss () {kubectl get statefulset}
    kcgi () {kubectl get ingress}
    kcgd () {kubectl get deployment}

    kcrm () {kubectl delete $1 $2 $3}
    kcrms () {kubectl delete service $1}
    kcrmd () {kubectl delete deployment $1}
    kcrmpv () {kubectl delete pv $1}
    kcrmpvc () {kubectl delete pvc $1}
    kcrmss () {kubectl delete statefulset $1}

    kcd () {kubectl describe $1 $2 $3}
    kcdp () {kubectl describe pod/$1}
    kcds () {kubectl describe service $1}

    kccd () {kubectl create deployment $1 --image=$2}
    kced () {kubectl edit deployment $1}
    kca () {kubectl apply -f $1}

    kcl () {kubectl logs $1}
    kct () {kubectl exec -it $1 -- /bin/bash}
    kctsh () {kubectl exec -it $1 -- /bin/sh}
    '
}
alias kc='kubectl'
kcg () {kubectl get $1 $2 $3}
kcgn () {kubectl get nodes}
kcgs () {kubectl get services}
kcgp () {kubectl get pods}
kcgpv () {kubectl get pv}
kcgpvc () {kubectl get pvc}
kcgpw () {kubectl get pods -o wide}
kcgr () {kubectl get replicaset}
kcgss () {kubectl get statefulset}
kcgi () {kubectl get ingress}
kcgd () {kubectl get deployment}

kcrm () {kubectl delete $1 $2 $3}
kcrms () {kubectl delete service $1}
kcrmd () {kubectl delete deployment $1}
kcrmpv () {kubectl delete pv $1}
kcrmpvc () {kubectl delete pvc $1}
kcrmss () {kubectl delete statefulset $1}

kcd () {kubectl describe $1 $2 $3}
kcdp () {kubectl describe pod/$1}
kcds () {kubectl describe service $1}

kccd () {kubectl create deployment $1 --image=$2}
kced () {kubectl edit deployment $1}
kca () {kubectl apply -f $1}

kcl () {kubectl logs $1}
kct () {kubectl exec -it $1 -- /bin/bash}
kctsh () {kubectl exec -it $1 -- /bin/sh}
kccp() {kubectl cp $1 $2}

#
# Localstack Helpers
alsalias(){
    echo '
        alsprofile (){export AWS_PROFILE=localstack;export AWS_PAGER=cat;}
        alias als="aws --endpoint-url http://localstack.test:4566"
    '
}
alsprofile (){export AWS_PROFILE=localstack;export AWS_PAGER=cat;}
alias als="aws --endpoint-url http://localstack.test:4566"



#
# Git Helpers
galias(){
    echo '
    gic () {git commit -a -m"$1";}
    gipl () {git pull --rebase}
    gips () {git push}
    gia () {git add -A}
    giac () {git add -A; git commit -a -m"$1";}
    gis () {git status}
    gic () {git checkout $1}
    gim () {git merge $1}
    gibl () {git branch}
    gibr () {git branch -r}ß
    giba () {git branch -a}
    gilbc () {git checkout -b $1}
    gilbd () {git branch -d "$1"}
    girbc () {git push --set-upstream origin "$1"}
    girbd () {git push origin -d "$1"}
    '    
}
gic () {git commit -a -m"$1";}
gipl () {git pull --rebase}
gips () {git push}
gia () {git add -A}
giac () {git add -A; git commit -a -m"$1";}
gis () {git status}
gic () {git checkout $1}
gim () {git merge $1}
gibl () {git branch}
gibr () {git branch -r}
giba () {git branch -a}
gilbc () {git checkout -b $1}
gilbd () {git branch -d "$1"}
girbc () {git push --set-upstream origin "$1"}
girbd () {git push origin -d "$1"}

#
# NPM Helpers
nupdatedep () {npm i -g npm-check-updates;ncu -u}

#nhydrate generator
export BLOCKCHAIN_HOME="/Users/dad/code/blockchain/datashare"
export SUPPLYCHAIN_HOME="/Users/dad/code/app.restrike.io"
export SANDBOX_HOME="/Users/dad/code/sandbox"
export NHYDRATE_HOME="/Users/dad/code/nHydrate/Source/nHydrate.Command.Core/bin/Debug/net5.0"
export NHYDRATE_GENERATORS="nHydrate.Generator.EFCodeFirstNetCore.EFCodeFirstNetCoreProjectGenerator,nHydrate.Generator.PostgresInstaller.PostgresDatabaseProjectGenerator"
ngen() {dotnet $NHYDRATE_HOME/nHydrate.Command.Core.dll "$@"}
ngenr() { ngen --model="$SUPPLYCHAIN_HOME/src/ModelProject/vuln.nhydrate" --generators="$NHYDRATE_GENERATORS" --output="$SUPPLYCHAIN_HOME/src" }
ngengit() { ngen --model="$SANDBOX_HOME/githubapp/server/model/githubintegration.nhydrate.yaml" --generators="$NHYDRATE_GENERATORS" --output="$SANDBOX_HOME/githubapp/server" }


#shift-arrow() {
#  ((REGION_ACTIVE)) || zle set-mark-command
#  zle $1
#}
#for key  kcap seq        widget (
#    left  LFT $'\e[1;2D' backward-char
#    right RIT $'\e[1;2C' forward-char
#    up    ri  $'\e[1;2A' up-line-or-history
#    down  ind $'\e[1;2B' down-line-or-history
#  ) {
#  functions[shift-$key]="zle set-mark-command; zle backward-char"
#  zle -N shift-$key
#  bindkey ${terminfo[k$kcap]-$seq} shift-$key
#}

#
# Switch Environments {Work, Default}
switchenv() {
   yes | cp ~/.nuget/NuGet/NuGet.Config.$1 ~/.nuget/NuGet/NuGet.Config
}
