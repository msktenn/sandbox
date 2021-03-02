#include "include/log.h"
#include <iostream>
#include <filesystem>
#include <stdio.h>
#include <stdlib.h>
#include <string>
#include "sha.h"
#include "md5.h"
#include "cryptlib.h"
#include "channels.h"
#include "filters.h"
#include "files.h"
#include "sha.h"
#include "crc.h"
#include "hex.h"

void shahash(std::string fileName)
{
    using namespace CryptoPP;

    try
    {
        std::string s1, s2, s3, s4, s5, s6;
        CRC32 crc;
        SHA1 sha1;
        SHA256 sha256;
        SHA512 sha512;
        MD5 md5;

        HashFilter f1(crc, new HexEncoder(new StringSink(s1)));
        HashFilter f2(sha1, new HexEncoder(new StringSink(s2)));
        HashFilter f3(sha256, new HexEncoder(new StringSink(s3)));
        HashFilter f4(sha512, new HexEncoder(new StringSink(s4)));
        HashFilter f5(md5, new HexEncoder(new StringSink(s5)));

        ChannelSwitch cs;
        cs.AddDefaultRoute(f1);
        cs.AddDefaultRoute(f2);
        cs.AddDefaultRoute(f3);
        cs.AddDefaultRoute(f4);
        cs.AddDefaultRoute(f5);

        FileSource(fileName.c_str(), true, new Redirector(cs));

        std::cout << "Filename: " << fileName << std::endl;
        std::cout << "   CRC32: " << s1 << std::endl;
        std::cout << "    SHA1: " << s2 << std::endl;
        std::cout << "    SHA256: " << s3 << std::endl;
        std::cout << "    SHA512: " << s4 << std::endl;
        std::cout << "    MD5: " << s5 << std::endl;
    }
    catch (const Exception &ex)
    {
        std::cerr << ex.what() << std::endl;
    }
}

namespace fs = std::filesystem;

int Multiply(int a, int b)
{
    Log("Multiply");
    return a * b;
}

void IncrementNoRef(int value)
{
    Log("Increment Int");
    value++;
}

void Increment(int *value)
{
    Log("Increment Int Pointer Passed In");
    //dereference
    //parenthesis required order of operation. Deref First;
    (*value)++;
}

void Increment(int &value)
{
    Log("Increment Reference Passed In");
    //reference is a pointer that you don't have to dereferences.
    value++;
}

void outputfilenames(std::string path)
{
    //const fs::path pathToShow{argc >= 2 ? argv[1] : fs::current_path()};
    const fs::path pathToShow = path;

    for (const auto &entry : fs::directory_iterator(pathToShow))
    {
        const auto filenameStr = entry.path().filename().string();
        if (entry.is_directory())
        {
            std::cout << "dir:  " << filenameStr << '\n';
            outputfilenames(entry.path());
        }
        else if (entry.is_regular_file())
        {
            std::cout << "file: " << filenameStr << '\n';
            shahash(entry.path().string());
        }
        else
            std::cout << "??    " << filenameStr << '\n';
    }
}

int main(int arc, char **arv)
{
    int var = 8;
    std::string foo;
    foo = arv[1];

    outputfilenames(foo);

    //address of var. & is different based on context.
    int *ptr = &var;
    std::cout << "1: " << var << " " << ptr << " " << &var << "\n";
    *ptr = 10;
    std::cout << "2: " << var << " " << ptr << " " << &var << "\n";
    IncrementNoRef(var);
    std::cout << "3: " << var << " " << ptr << " " << &var << "\n";
    Increment(&var);
    std::cout << "4: " << var << " " << ptr << " " << &var << "\n";
    Increment(&var);
    std::cout << "5: " << var << " " << ptr << " " << &var << "\n";
    std::cout << arc;
    std::cout << arv[1];
    std::cout << Multiply(5, 8) << std::endl;
    std::cout << "Hello, world!\n";
    return 0;
}
