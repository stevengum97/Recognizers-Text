# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

from setuptools import setup, find_packages

NAME = "recognizers-text-number"
VERSION = "1.0.0.a0"
REQUIRES = ['recognizers-text', 'regex']

setup(
    name=NAME,
    version=VERSION,
    url='https://github.com/Microsoft/Recognizers-Text',
    author='Microsoft',
    description='recognizers-text-number README',
    keywords=[ 'nlp', 'nlp-entity-extraction', 'entity-extraction', 'parser-library' ],
    long_description='recognizers-text-number long README.',
    license='MIT',
    packages=find_packages(),
    install_requires=REQUIRES,
    classifiers=[
        'Programming Language :: Python :: 3.6',
        'Intended Audience :: Developers',
        'License :: OSI Approved :: MIT License',
        'Operating System :: OS Independent',
        'Development Status :: 3 - Alpha',
        'Topic :: Scientific/Engineering :: Artificial Intelligence',
    ]
)
