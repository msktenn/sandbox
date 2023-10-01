Commands run to start this project

```bash
npm init -y
npm i -D typescript
npx tsc --init
npm i -D ts-node
npm install dotenv --save
```

This application uses .env to set environmental variables during configuration. The .env file is not checked in. As such you will need to create one.

```bash
touch .env
```

After creating the file add the following configuration items. If you create more config items please add them to this list.

```dosini
LOGLEVEL=DEBUG
LOGFORMAT=PRETTY
```

node 'node*modules/.bin/jest' '/Users/dad/code/blockchain/datashare/client/tsbasics/test/config.spec.ts' '/Users/dad/code/blockchain/datashare/client/tsbasics/test/config2.spec.ts' -c '/Users/dad/code/blockchain/datashare/client/tsbasics/jest.config.js' -t 'Configuration' --testLocationInResults --json --useStderr --outputFile /var/folders/j*/pj5s80wn2ds7dh_j28ft70_m0000gn/T/jest_runner_tsbasics_501.json --watch --no-coverage --reporters default --reporters /Users/mknight/.vscode/extensions/orta.vscode-jest-5.2.3/out/reporter.js --colors
