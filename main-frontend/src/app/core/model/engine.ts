import { Classification } from './classification';
import { Crew } from './crew';

export class Engine {
    EngineId: number;
    EngineNumber: string;
    EnginePs: number;
    EngineCapacityCcm: number;
    EngineCylinder: number;
    EngineConstructionYear: number;
    EngineLength: number;
    EngineWidth: number;
    EngineHight: number;
    EngineBody: string;
    EngineChassis: string;
    EngineIsDeprecated: boolean;
    EngineLicensePlate: string;
    EngineRadioCall: string;
    Crew: Crew;
    Classification: Classification;_
}
