import { ValueEndpoint, EntropyEndpoint } from './Constants';

export function GetTypeDefinitionsEndpoint() {
    return `${ValueEndpoint}/typedefinitions`
}

export function GetEntropyResultEndpoint(entropyType) {
    return `${EntropyEndpoint}?entropyTypeID=${entropyType}`
}