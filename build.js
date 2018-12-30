const { execSync } = require('child_process');
const { copyFileSync } = require('fs');

const targets = [
    "win7-x64",
    "win7-x86",
    "win8-x64",
    "win8-x86",
    "win81-x64",
    "win81-x86",
    "win10-x64",
    "win10-x86",
    "debian-x64",
    "debian.9-x64",
    "ubuntu-x64",
    "ubuntu.16.04-x64",
    "ubuntu.18.04-x64",
    "linuxmint.17-x64",
    "linuxmint.18-x64",
    "linuxmint.18.1-x64",
    "linuxmint.18.2-x64",
    "linuxmint.18.3-x64"
];

for (const target of targets) {
    console.log(`building ${target}...`);
    execSync(`dotnet publish -c Release -r ${target} -o build/${target}`);
    console.log(`building ${target} completed.`)
    copyFileSync('dfa.txt', `build/${target}/dfa.txt`);
}
