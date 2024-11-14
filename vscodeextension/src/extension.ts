// The module 'vscode' contains the VS Code extensibility API
// Import the module and reference it with the alias vscode in your code below
import * as vscode from 'vscode';
import { window } from 'vscode';
import { isNullOrUndefined } from 'util';


class LastTest {
	private static instance: LastTest;

	public lastFileName: string;
	public lastMethodName: string;

	/**
	 * The Singleton's constructor should always be private to prevent direct
	 * construction calls with the `new` operator.
	 */
	private constructor() {
		this.lastFileName = '';
		this.lastMethodName = '';
	}

	/**
	 * The static method that controls the access to the singleton instance.
	 *
	 * This implementation let you subclass the Singleton class while keeping
	 * just one instance of each subclass around.
	 */
	public static getInstance(): LastTest {
		if (!LastTest.instance) {
			LastTest.instance = new LastTest();
		}
		return LastTest.instance;
	}

}


// this method is called when your extension is activated
// your extension is activated the very first time the command is executed
export function activate(context: vscode.ExtensionContext) {

	// Use the console to output diagnostic information (console.log) and errors (console.error)
	// This line of code will only be executed once when your extension is activated
	console.log('Congratulations, your extension "michaelknight" is now active!');


	// The command has been defined in the package.json file
	// Now provide the implementation of the command with registerCommand
	// The commandId parameter must match the command field in package.json
	let disposable = vscode.commands.registerCommand('michaelknight.test.debug', () => {
		if (!isNullOrUndefined(window.activeTextEditor)) {
			getClassName().then(function (className) {
				getFileName().then(function (fileName) {
					LastTest.getInstance().lastMethodName = isNullOrUndefined(className) ? '' : className;
					LastTest.getInstance().lastFileName = isNullOrUndefined(fileName) ? '' : fileName;;
					vscode.commands.executeCommand('dotnet.test.debug', className, fileName, 'xunit');
				});
			});
		}
	});
	let disposable2 = vscode.commands.registerCommand('michaelknight.test.runlast', () => {
		vscode.commands.executeCommand('dotnet.test.debug', LastTest.getInstance().lastMethodName, LastTest.getInstance().lastFileName, 'xunit');
	});
	context.subscriptions.push(disposable);
	context.subscriptions.push(disposable2);
}

async function getClassName() {
	const result = await window.showInputBox({
		value: '',
		valueSelection: [2, 4],
		placeHolder: '<namespace>.<classname>',
		validateInput: text => {
			return null;
		}
	});
	return result;
}

async function getFileName() {
	let currentFileName = window.activeTextEditor?.document.fileName;
	const result = await window.showInputBox({
		value: currentFileName,
		valueSelection: [2, 4],
		placeHolder: 'fileName',
		validateInput: text => {
			return null;
		}
	});
	return result;
}


// this method is called when your extension is deactivated
export function deactivate() { }
